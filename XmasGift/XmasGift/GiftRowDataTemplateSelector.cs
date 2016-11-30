using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XmasGift
{
    public class GiftRowDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GiftAssignedTemplate { get; set; }
        public DataTemplate GiftNotAssignedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((GiftInfo)item).Price == 0.0 ? GiftNotAssignedTemplate : GiftAssignedTemplate;
        }
    }
}
