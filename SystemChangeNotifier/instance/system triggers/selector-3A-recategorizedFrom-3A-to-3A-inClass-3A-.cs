selector: selector recategorizedFrom: oldCategory to: newCategory inClass: aClass

	self trigger: (RecategorizedEvent 
				method: (aClass compiledMethodAt: selector ifAbsent: [nil])
				protocol: newCategory
				class: aClass
				oldProtocol: oldCategory)