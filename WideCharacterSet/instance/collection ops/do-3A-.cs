do: aBlock 
	map
		keysAndValuesDo: [:high :lowmap | self
				bitmap: lowmap
				do: [:low | aBlock
						value: (Character value: ((high bitShift: 16) bitOr: low))]]