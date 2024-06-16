using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ShareEdu.Factory.PL.TagHelpers
{
    [HtmlTargetElement("confirmation-modal")]
    public class ConfirmationModalTagHelper : TagHelper
    {
        public string ModalId { get; set; }
        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string ButtonText { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            // Generate the modal dialog markup
            output.Content.SetHtmlContent($@"
                <div class='modal fade' id='{ModalId}' tabindex='-1' role='dialog' aria-labelledby='{TitleId}' aria-hidden='true'>
                    <div class='modal-dialog' role='document'>
                        <div class='modal-content'>
                            <div class='modal-header'>
                                <h5 class='modal-title' id='{TitleId}'>{Title}</h5>
                                <button type='button' class='close' data-dismiss='modal' aria-label='Close'>
                                    <span aria-hidden='true'>&times;</span>
                                </button>
                            </div>
                            <div class='modal-body'>
                                <p>{Message}</p>
                            </div>
                            <div class='modal-footer'>
                                <form method='post' action='/{Controller}/{Action}'>
                                    <button type='button' class='btn btn-outline-secondary' data-dismiss='modal'>Close</button>
                                    <button type='submit' class='btn btn-outline-primary'>{ButtonText}</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            ");
        }
    }
}
