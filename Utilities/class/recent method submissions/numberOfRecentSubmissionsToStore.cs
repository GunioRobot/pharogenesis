numberOfRecentSubmissionsToStore
	"Answer how many methods back the 'recent method submissions' history should store"

	^ Preferences parameterAt: #numberOfRecentSubmissionsToStore ifAbsentPut: [30]