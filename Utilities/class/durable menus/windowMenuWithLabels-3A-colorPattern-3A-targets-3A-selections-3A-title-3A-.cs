windowMenuWithLabels: labelList colorPattern: colorPattern  targets: targetList selections: selectionList title: aTitle
	| aWorld n   colorList  pos delta aButton  rightmost |

	aWorld _ WorldMorph new.
	n _ labelList size.

	colorList _  (1 to: n) asArray  collect:
		[:ind | Color perform: (colorPattern at: (ind \\ colorPattern size + 1))].
			
	pos _ 4 @ 2.
	delta _ 0 @ 30.
	rightmost _ 0.

	1 to: labelList size do:
		[:index |
			aButton _ SimpleButtonMorph new.
			aButton label: (labelList at: index); 
				color: (colorList at: index); 
				target: (targetList at: index);
				actionSelector: (selectionList at: index);
				position: pos.
			rightmost _ rightmost max: aButton right.
			pos _ pos + delta.
			aWorld addMorphBack: aButton].
	aWorld setProperty: #initialExtent toValue: ((rightmost @ aButton bottom) + (10@10)).
	aWorld openWithTitle: aTitle