advance: anInteger containingDirectoriesFrom: aDirectory

	| theDirectory |
	theDirectory _ aDirectory.
	1 to: anInteger do: [:i | theDirectory _ theDirectory containingDirectory].
	^theDirectory