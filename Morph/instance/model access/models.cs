models
	"Answer a collection of whatever models I may have."

	self modelOrNil ifNil: [ ^EmptyArray ].
	^Array with: self modelOrNil