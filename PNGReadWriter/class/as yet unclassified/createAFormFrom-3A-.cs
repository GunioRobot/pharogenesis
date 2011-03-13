createAFormFrom: data

	| error f |

	error _ ''.
	f _ [
		self formFromStream: (RWBinaryOrTextStream with: data)
	] ifError: [ :a :b |
		error _ a printString,'  ',b printString.
		(StringMorph contents: error) color: Color red; imageForm
	].
	^{f. error}