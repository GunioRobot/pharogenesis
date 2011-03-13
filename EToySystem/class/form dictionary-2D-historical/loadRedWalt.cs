loadRedWalt
	"Read in the Alan's red Walt Disney text."
	"EToySystem loadRedWalt"

	| f |
	f _ FileStream oldFileNamed: 'CleanedUpWaltRed.morph'.
	self formDictionary at: 'RedWalt' put: f fileInObjectAndCode.
	EToyParameters classPool at: #WaltPicPt put: -28@52.
