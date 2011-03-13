setRed: r green: g blue: b range: zeroToThis
	"Initialize this color's r, g, and b components to the given values in [0.0..1.0].  Range is [0..r], a weird numbering system with size r+epsilon, min 0, max r.  6/14/96 tk"
	| range |

	range _ zeroToThis.
	rgb == nil ifFalse: [^ self error: 'Can''t write into a Color.  Make a new one'].
	rgb _
		((((r * ComponentMask) // range) bitAnd: ComponentMask) bitShift: RedShift) +
		((((g * ComponentMask) // range) bitAnd: ComponentMask) bitShift: GreenShift) +
		 (((b * ComponentMask) // range) bitAnd: ComponentMask)