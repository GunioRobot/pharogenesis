selectedMethod
	^ methodText ifNil: [methodText _ selectedContext
						ifNil: ['']
						ifNotNil: [| pcRange | 
							methodText _ [ selectedContext sourceCode ]
								ifError: [ :err :rcvr | 'error getting method text' ].
							pcRange _ self pcRange.
							methodText asText
								addAttribute: TextColor red
								from: pcRange first
								to: pcRange last;
								
								addAttribute: TextEmphasis bold
								from: pcRange first
								to: pcRange last]]