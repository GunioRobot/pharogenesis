okStreamArrayClass: cl

	^(cl = (self splObj: ClassString) or:
	  [cl = (self splObj: ClassArray) or:
	  [cl = (self splObj: ClassByteArray) or:
	  [cl = (self splObj: ClassBitmap)]]])