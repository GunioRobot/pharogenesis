addSelectorsReferingTo: aSymbol in: class to: sortedSenders special: special byte: byte 
	{class. class class} do: [:behavior| (behavior 
		thoroughWhichSelectorsReferTo: aSymbol
		special: special
		byte: byte) do: [ :sel | 
			sortedSenders add: (MethodReference 
				class: class
				selector: sel) ]]