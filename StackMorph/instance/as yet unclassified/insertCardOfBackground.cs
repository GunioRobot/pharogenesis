insertCardOfBackground
	"Prompt the user for choice of a background, and insert a new card of that background"

	| bgs aMenu aBackground |
	(bgs := self backgrounds) size == 1 ifTrue:
		[self inform: 
'At this time, there IS only one kind of
background in this stack, so that''s
what you''ll get' translated.
		^ self insertCard].
	aMenu := SelectionMenu
		labels: 		(bgs collect: [:bg | bg externalName])
		selections: 	bgs.
	(aBackground := aMenu startUp) ifNotNil:
		[self insertCardOfBackground: aBackground]