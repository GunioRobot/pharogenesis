setupColorMasksFrom: srcBits to: targetBits
	"Setup color masks for converting an incoming RGB pixel value from srcBits to targetBits."
	| delta mask |
	cmDeltaBits _ targetBits - srcBits.
	cmDeltaBits <= 0
		ifTrue:[	mask _ 1 << targetBits - 1.
				delta _ srcBits - targetBits.
				"Mask for extracting a color part of the source"
				cmRedMask _ mask << (srcBits*2 - cmDeltaBits).
				cmGreenMask _ mask << (srcBits - cmDeltaBits).
				cmBlueMask _ mask << (0 - cmDeltaBits)]
		ifFalse:[	mask _ 1 << srcBits - 1.
				delta _ targetBits - srcBits.
				"Mask for extracting a color part of the source"
				cmRedMask _ mask << (srcBits*2).
				cmGreenMask _ mask << srcBits.
				cmBlueMask _ mask].

	"Shifts for adjusting each value in a cm RGB value"
	cmRedShift _ delta * 3.
	cmGreenShift _ delta * 2.
	cmBlueShift _ delta.