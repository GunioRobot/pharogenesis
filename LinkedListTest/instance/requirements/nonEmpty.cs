nonEmpty
	^ nonEmpty ifNil: [nonEmpty := LinkedList with: self element with: Link new]