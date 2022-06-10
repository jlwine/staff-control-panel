using System.ComponentModel.DataAnnotations;
namespace staff_control_panel.CustomValidation
{
    public class DateValidation:ValidationAttribute
    {
        public DateValidation() : base("{0} Дата должен быть меньше")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);
            if (propValue <= DateTime.Now)
                return true;
            else
                return false;
        }
    }
}
