drawOn: aCanvas
	"Draw my submorphs as a shadow, then fullDrawOn will droaw them normally."
	submorphs isEmpty ifTrue: [^ super drawOn: aCanvas].
	aCanvas translateBy: shadowOffset during:[:shadowCanvas|
		shadowCanvas shadowColor: color.
		self drawSubmorphsOn: shadowCanvas].