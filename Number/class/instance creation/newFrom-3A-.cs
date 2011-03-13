newFrom: aSimilarObject
	"Create an object that has similar contents to aSimilarObject."

	^self new coerce: aSimilarObject

"	4 as: Float   4.0
	4 as: Fraction   (4/1)
	4 as: Integer   4
	(4 as: Integer) class   SmallInteger
	(4 as: LargePositiveInteger) class   SmallInteger
	4 as: SmallInteger   (error)
"