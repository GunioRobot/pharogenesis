help
	| window helpMorph |

	window _ SystemWindow labelled: 'FreeCell Help'.
	window model: self.
	helpMorph _ (PluggableTextMorph new editString: self helpText)
				 lock.
	window addMorph: helpMorph frame: (0@0 extent: 1@1).
	window openInWorld.
