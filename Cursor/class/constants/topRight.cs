topRight
	"Cursor topRight showWhile: [Sensor waitButton]"
	^ (Cursor extent: 16@16
			fromArray: #(
		2r1111111111111111
		2r1111111111111111
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011
		2r0000000000000011)
			offset: -16@0).
