assuredCardPlayer
	"Answer the receiver's player, creating a new one if none currently exists"

	| aPlayer |
	(aPlayer _ self player) ifNotNil: [
		(aPlayer isKindOf: CardPlayer) 
				ifTrue: [^ aPlayer]
				ifFalse: [self error: 'Must convert to a CardPlayer']
					"later convert using as: and remove the error"].
	self assureExternalName.  "a default may be given if not named yet"
	self player: (aPlayer _ UnscriptedCardPlayer newUserInstance).
		"Force it to be a CardPlayer.  Morph class no longer dictates what kind of player"
	aPlayer costume: self.
	self presenter ifNotNil: [self presenter flushPlayerListCache].
	^ aPlayer