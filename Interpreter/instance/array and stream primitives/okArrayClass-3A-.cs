okArrayClass: cl

	^(cl = (self splObj: ClassArray) or:
	  [cl = (self splObj: ClassBitmap) or:
	  [cl = (self splObj: ClassByteArray)]])