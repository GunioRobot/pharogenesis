new
	"NOTE: Use newFromFile: rather than new to create new CrosticPanels"

	^ self newFromFile: (ReadStream on: self sampleFile)