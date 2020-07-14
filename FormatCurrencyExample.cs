 
 
 //FORMATA O VALOR FINAL SEM ARREDONDAR
  public static decimal TruncateDecimal(decimal value, int precision)
  {
      decimal step = (decimal)Math.Pow(10, precision);
      decimal tmp = Math.Truncate(step * value);
      return tmp / step;
  }
