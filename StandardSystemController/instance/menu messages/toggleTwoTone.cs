toggleTwoTone
	(view isMemberOf: StandardSystemView) ifTrue:
		[^ view become: (view as: ColorSystemView)].
	(view isMemberOf: ColorSystemView) ifTrue:
		[^ view become: (view as: StandardSystemView)].
