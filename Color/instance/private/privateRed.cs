privateRed
	"Private! Answer the internal representation of my red component."

	^ (rgb bitShift: 0 - RedShift) bitAnd: ComponentMask