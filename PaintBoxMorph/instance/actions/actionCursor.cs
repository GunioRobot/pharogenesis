actionCursor
	"Return the cursor to use with this painting action/tool. Offset of the form must be set."

	| ff width co larger c box |

action == #paint: ifTrue: ["Make a cursor from the brush and the color"
		width _ self getNib width.
		c _ self ringColor.
		co _ (currentCursor offset - ((width//4)@34-(width//6))) min: (0@0).
		
		larger _ width negated + 10@0 extent: currentCursor extent + (width@width).
		ff _ currentCursor copy: larger.
		ff colors at: 1 put: Color transparent.
         	ff colors at: 2 put: Color transparent.
	
          ff offset: co - (width@width //2).
            (ff getCanvas) fillOval: (Rectangle center: ff offset negated
						extent: width@width)
                        color: Color transparent
                        borderWidth: 1
                        borderColor: c.
	 	 ^ ff].
	
	action == #erase: ifTrue: ["Make a cursor from the cursor and the color"
		width _ self getNib width.
		co _ (currentCursor offset + (width//2@4)) min: (0@0).
		larger _ 0@0 extent: currentCursor extent + (width@width).
		ff _ currentCursor copy: larger.
		ff offset: co - (width@width //2).
		ff fill: (box _ co negated extent: (width@width)) 
					fillColor: (Color r: 0.5 g: 0.5 b: 1.0).
		ff fill: (box insetBy: 1@1) fillColor: Color transparent.
		
		^ ff].

	^ currentCursor
