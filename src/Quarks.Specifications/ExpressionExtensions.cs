﻿using System;
using System.Linq.Expressions;

namespace Quarks.Specifications
{
	internal static class ExpressionExtensions
	{
		public static Expression<Func<T, bool>> AndAlso<T>(
			this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			ParameterExpression param = expr1.Parameters[0];
			if (ReferenceEquals(param, expr2.Parameters[0]))
			{
				return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, expr2.Body), param);
			}
			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, Expression.Invoke(expr2, param)), param);
		}

		public static Expression<Func<T, bool>> OrElse<T>(
			this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
		{
			ParameterExpression param = expr1.Parameters[0];
			if (ReferenceEquals(param, expr2.Parameters[0]))
			{
				return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, expr2.Body), param);
			}
			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, Expression.Invoke(expr2, param)), param);
		}
	}
}