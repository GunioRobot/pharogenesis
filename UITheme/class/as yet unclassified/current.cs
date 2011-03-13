current
	"Answer the current ui theme."

	^Current ifNil: [Current := UIThemeSoftSqueak newDefault. Current]