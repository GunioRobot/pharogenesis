indexOf: anElement startingAt: startIndex ifAbsent: exceptionBlock
   "  startIndex is an positive integer, the collection index where the search is started. "
   " during the computation of  val , floats are only used when the receiver contains floats "

   | index val |
   (self rangeIncludes: anElement) 
      ifFalse: [^0]. 
  	val _ (anElement - self first)  / self increment.
	val fractionPart abs * 100000000 < step abs
	  ifFalse: [^0]
	  ifTrue: [index := val rounded + 1].
   " finally, the value of  startIndex  comes into play: "
   ^index < startIndex
      ifTrue: [0]
      ifFalse: [index].