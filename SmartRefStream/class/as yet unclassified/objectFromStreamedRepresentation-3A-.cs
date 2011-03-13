objectFromStreamedRepresentation: someBytes

	| file |

	file _ RWBinaryOrTextStream with: someBytes.
	file reset.
	^file fileInObjectAndCode