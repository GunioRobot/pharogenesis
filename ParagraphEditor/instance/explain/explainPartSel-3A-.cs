explainPartSel: string 
	"Is this a fragment of a multiple-argument selector sent in this method?"
	| lits whole reply classes s msg |

	(model respondsTo: #selectedMessageName) ifFalse: [^ nil].
	(msg _ model selectedMessageName) ifNil: [^ nil].  "not in a message"
	string last == $: ifFalse: [^ nil].
	"Name of this method"
	lits _ Array with: msg.
	(whole _ lits detect: [:each | (each keywords detect: [:frag | frag = string]
					ifNone: []) ~~ nil]
				ifNone: []) ~~ nil
		ifTrue: [reply _ ', which is the selector of this very method!'.
			s _ '.  To see the other definitions, go to the message list pane, get the menu from the top of the scroll bar, and select ''implementors of...''."']
		ifFalse: 
			["Selectors called from this method"
			lits _ (model selectedClassOrMetaClass compiledMethodAt:
				msg) messages.
			(whole _ lits detect: [:each | (each keywords detect: [:frag | frag = string]
							ifNone: []) ~~ nil]
						ifNone: []) ~~ nil
				ifFalse: [string = 'primitive:'
					ifTrue: [^self explainChar: '<']
					ifFalse: [^nil]].
			reply _ '.'.
			s _ '.  To see the definitions, go to the message list pane, get the menu from the top of the scroll bar, and select ''implementors of...''."'].
	classes _ self systemNavigation allClassesImplementing: whole.
	classes size > 12
		ifTrue: [classes _ 'many classes']
		ifFalse: [classes _ 'these classes ' , classes printString].
	^ '"' , string , ' is one part of the message selector ' , whole, reply , '  It is defined in ' , classes , s