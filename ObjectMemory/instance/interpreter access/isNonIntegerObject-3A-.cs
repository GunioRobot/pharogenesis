isNonIntegerObject: objectPointer

	^ (objectPointer bitAnd: 1) = 0