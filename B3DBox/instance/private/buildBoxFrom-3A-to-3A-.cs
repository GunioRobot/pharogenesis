buildBoxFrom: origin to: corner
	vertices := Array new: 8.
	1 to: 8 do:[:i| vertices at: i put: B3DVector3 new].

	(vertices at: 1) x: origin x.	(vertices at: 1) y: origin y.	(vertices at: 1) z: origin z.
	(vertices at: 2) x: origin x.	(vertices at: 2) y: origin y.	(vertices at: 2) z: corner z.
	(vertices at: 3) x: origin x.	(vertices at: 3) y: corner y.	(vertices at: 3) z: corner z.
	(vertices at: 4) x: origin x.	(vertices at: 4) y: corner y.	(vertices at: 4) z: origin z.
	(vertices at: 5) x: corner x.	(vertices at: 5) y: origin y.	(vertices at: 5) z: origin z.
	(vertices at: 6) x: corner x.	(vertices at: 6) y: origin y.	(vertices at: 6) z: corner z.
	(vertices at: 7) x: corner x.	(vertices at: 7) y: corner y.	(vertices at: 7) z: corner z.
	(vertices at: 8) x: corner x.	(vertices at: 8) y: corner y.	(vertices at: 8) z: origin z.
