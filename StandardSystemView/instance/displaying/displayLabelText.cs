displayLabelText
	"The label goes in the center of the window"
	| labelRect |
	labelText foregroundColor: self foregroundColor
			backgroundColor: self labelColor.
	labelRect _ self labelTextRegion.
	Display fill: (labelRect expandBy: 3@0) fillColor: self labelColor.
	labelText displayOn: Display at: labelRect topLeft clippingBox: labelRect
			rule: labelText rule fillColor: labelText fillColor.
	labelText destinationForm: nil