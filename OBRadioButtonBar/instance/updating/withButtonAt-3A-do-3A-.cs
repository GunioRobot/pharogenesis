withButtonAt: index do: aBlock
	^ (buttons at: index ifAbsent: [nil]) ifNotNilDo: aBlock