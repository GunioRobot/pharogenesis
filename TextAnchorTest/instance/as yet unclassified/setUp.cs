setUp
	super setUp.
	prototypes
		add: (TextAnchor new anchoredMorph: RectangleMorph new initialize);
		
		add: (TextAnchor new anchoredMorph: EllipseMorph new initialize) 