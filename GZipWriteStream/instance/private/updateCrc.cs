updateCrc
	crcPosition <= position ifTrue:[
		bytesWritten _ bytesWritten + position - crcPosition + 1.
		crc _ self updateCrc: crc from: crcPosition to: position in: collection.
		crcPosition _ position + 1].