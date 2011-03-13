initialize  "PinMorph initialize"
	OutputPinForm _ Form extent: 8@8 depth: 1 fromArray:
			#( 0 3221225472 4026531840 4227858432 4278190080 4227858432 4026531840 3221225472)
		offset: 0@0.

	IoPinForm _ Form extent: 8@8 depth: 1 fromArray:
			#( 0 402653184 1006632960 2113929216 4278190080 2113929216 1006632960 402653184)
		offset: 0@0.

	InputPinForm _ OutputPinForm flipBy: #horizontal centerAt: 0@0.
