unusedSoundNameLike: desiredName
	"Pick an unused sound name based on the given string. If necessary, append digits to avoid name conflicts with existing sounds."
	"SampledSound unusedSoundNameLike: 'chirp'"

	| newName i |
	newName _ desiredName.
	i _ 2.
	[SoundLibrary includesKey: newName] whileTrue: [
		newName _ desiredName, i printString.
		i _ i + 1].
	^ newName
