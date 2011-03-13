regionOf: pt 

| px py reg xl yl yh xr rg |
"it's some other character"	rg _ in/3. 	xl _ bmin x + rg x. xr _ bmax x - rg x.
"divide box into 9 regions"				yl _ bmin y + rg y. yh _ bmax y - rg y.

					px _ pt x. py _ pt y.
					reg _ (px < xl ifTrue: [py < yl ifTrue: ['NW ']
										"py >= yl"	ifFalse:[ py < yh ifTrue:['W ']
																	ifFalse: ['SW ']]]
					ifFalse: [px < xr ifTrue: [py < yl ifTrue: ['N ']
													ifFalse: [py < yh ifTrue: ['C ']
																	ifFalse: ['S ']]]
					ifFalse: [py < yl ifTrue: ['NE ']
									ifFalse: [py < yh ifTrue: ['E ']
													ifFalse: ['SE ']]]]).
^reg.
					