# Run the following commands to illustrate the problem:

```
dotnet ef database update
dotnet run
```

# It produces the following output:

```
Inserting a new blog
Querying for a blog
Updating the blog and adding a post
This works: Querying for a post (Using primitive type)
THIS BREAKS! Querying for a post (Using Value Object)
Unhandled exception. System.InvalidOperationException: No backing field could be found for property 'Status.PostId' and the property does not have a getter.
   at Microsoft.EntityFrameworkCore.Metadata.IPropertyBase.GetMemberInfo(Boolean forMaterialization, Boolean forSet)
   at Microsoft.EntityFrameworkCore.Metadata.Internal.ClrPropertyGetterFactory.Create(IPropertyBase property)
   at Microsoft.EntityFrameworkCore.Metadata.RuntimePropertyBase.<>c.<Microsoft.EntityFrameworkCore.Metadata.IPropertyBase.GetGetter>b__35_0(RuntimePropertyBase property)
   at Microsoft.EntityFrameworkCore.Internal.NonCapturingLazyInitializer.EnsureInitialized[TParam,TValue](TValue& target, TParam param, Func`2 valueFactory)
   at Microsoft.EntityFrameworkCore.Metadata.RuntimePropertyBase.Microsoft.EntityFrameworkCore.Metadata.IPropertyBase.GetGetter()
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.CreatePropertyAccessExpression(Expression target, IProperty property)
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.<>c__DisplayClass51_0.<TryRewriteEntityEquality>b__0(IProperty p)
   at System.Linq.Enumerable.SelectEnumerableIterator`2.MoveNext()
   at System.Linq.Enumerable.Aggregate[TSource](IEnumerable`1 source, Func`3 func)
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.TryRewriteEntityEquality(ExpressionType nodeType, Expression left, Expression right, Boolean equalsMethod, Expression& result)
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)
   at System.Linq.Expressions.MethodCallExpression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.TranslateInternal(Expression expression)
   at Microsoft.EntityFrameworkCore.Query.RelationalSqlTranslatingExpressionVisitor.Translate(Expression expression)
   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.TranslateExpression(Expression expression)
   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.TranslateLambdaExpression(ShapedQueryExpression shapedQueryExpression, LambdaExpression lambdaExpression)
   at Microsoft.EntityFrameworkCore.Query.RelationalQueryableMethodTranslatingExpressionVisitor.TranslateWhere(ShapedQueryExpression source, LambdaExpression predicate)
   at Microsoft.EntityFrameworkCore.Query.QueryableMethodTranslatingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)
   at System.Linq.Expressions.MethodCallExpression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at Microsoft.EntityFrameworkCore.Query.QueryableMethodTranslatingExpressionVisitor.VisitMethodCall(MethodCallExpression methodCallExpression)
   at System.Linq.Expressions.MethodCallExpression.Accept(ExpressionVisitor visitor)
   at System.Linq.Expressions.ExpressionVisitor.Visit(Expression node)
   at Microsoft.EntityFrameworkCore.Query.QueryCompilationContext.CreateQueryExecutor[TResult](Expression query)
   at Microsoft.EntityFrameworkCore.Storage.Database.CompileQuery[TResult](Expression query, Boolean async)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.CompileQueryCore[TResult](IDatabase database, Expression query, IModel model, Boolean async)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.<>c__DisplayClass9_0`1.<Execute>b__0()
   at Microsoft.EntityFrameworkCore.Query.Internal.CompiledQueryCache.GetOrAddQuery[TResult](Object cacheKey, Func`1 compiler)
   at Microsoft.EntityFrameworkCore.Query.Internal.QueryCompiler.Execute[TResult](Expression query)
   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryProvider.Execute[TResult](Expression expression)
   at Microsoft.EntityFrameworkCore.Query.Internal.EntityQueryable`1.GetEnumerator()
   at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
   at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
   at Program.<Main>$(String[] args) in /Users/johann/source/sandbox/EFCoreValueObjectPredicateExample/Program.cs:line 33

```