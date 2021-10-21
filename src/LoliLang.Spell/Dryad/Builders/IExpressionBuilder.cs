
namespace LoliLang.Spell.Dryad.Builders
{
    public interface IExpressionBuilder
    {
        Expression Answer();
        IExpressionBuilder With(Expression expression);
        IExpressionBuilder Und(Expression expression);

        IExpressionBuilder NewOfType<T>() where T : Expression;
    }
}