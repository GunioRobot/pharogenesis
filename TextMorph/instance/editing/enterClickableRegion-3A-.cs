enterClickableRegion: evt
	| index isLink |
	evt hand hasSubmorphs ifTrue:[^self].
	evt hand temporaryCursor ifNotNil:[^self].
	paragraph ifNotNil:[
		index _ (paragraph characterBlockAtPoint: evt position) stringIndex.
		isLink _ (paragraph text attributesAt: index forStyle: paragraph textStyle) 
					anySatisfy:[:attr| attr mayActOnClick].
		isLink ifTrue:[Cursor webLink show] ifFalse:[Cursor normal show].
	].
