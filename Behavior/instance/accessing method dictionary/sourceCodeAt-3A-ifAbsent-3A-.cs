sourceCodeAt: selector ifAbsent: aBlock

	^ (methodDict at: selector ifAbsent: [^ aBlock value]) getSourceFor: selector in: self