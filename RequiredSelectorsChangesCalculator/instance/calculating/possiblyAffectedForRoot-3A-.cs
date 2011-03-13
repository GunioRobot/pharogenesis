possiblyAffectedForRoot: rootClass
	^possiblyAffectedPerRoot at: rootClass ifAbsentPut: [IdentitySet new].