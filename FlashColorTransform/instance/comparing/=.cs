= aCT
	self class == aCT class ifFalse:[^false].
	^rAdd = aCT rAdd and:[rMul = aCT rMul and:[
		gAdd = aCT gAdd and:[gMul = aCT gMul and:[
			bAdd = aCT bAdd and:[bMul = aCT bMul and:[
				aAdd = aCT aAdd and:[aMul = aCT aMul]]]]]]]