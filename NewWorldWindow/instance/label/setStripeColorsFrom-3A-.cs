setStripeColorsFrom: paneColor
	"Since our world may be *any* color, try to avoid really dark colors so title will show"

	| revisedColor |
	stripes ifNil: [^ self].
	revisedColor _ paneColor atLeastAsLuminentAs: 0.1 .
	self isActive ifTrue:
		[stripes second 
			color: revisedColor; 
			borderColor: stripes second color darker.
		stripes first 
			color: stripes second borderColor darker;
			borderColor: stripes first color darker.
		^ self].
	"This could be much faster"
	stripes second 
		color: revisedColor; 
		borderColor: revisedColor.
	stripes first 
		color: revisedColor; 
		borderColor: revisedColor