customPartsBin
	CustomPartsBin ifNil:
		[self inform: 
'There is no custom parts bin yet.
To create one, start with a Standard Parts Bin, 
and modify it as you wish, and then choose
''Save as Custom Parts Bin'' from the
parts-window-controls menu, which
will be found in the halo menu of
any parts-bin window'.
	^ nil].

	^ CustomPartsBin veryDeepCopy