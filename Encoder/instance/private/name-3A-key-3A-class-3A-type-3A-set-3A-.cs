name: name key: key class: leafNodeClass type: type set: dict

	^dict 
		at: key
		ifAbsent: 
			[dict
				at: key
				put: (leafNodeClass new
						name: name
						key: key
						index: nil
						type: type)]