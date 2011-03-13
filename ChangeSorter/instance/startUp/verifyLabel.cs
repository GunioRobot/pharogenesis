verifyLabel
	"May have changed since we last were in this window"
	buttonView == nil ifTrue: [^ self].
	buttonView topView label asString = self label 
		ifFalse: [buttonView topView relabel: self label].
