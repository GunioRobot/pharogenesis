subtractDays: dayCount 
	"Answer a Date that is dayCount days before the receiver."

	^self addDays: dayCount negated.