invalidRect: damageRect from: aMorph
        "Clip damage reports to my bounds, since drawing is clipped to my bounds."

        self == self outermostWorldMorph 
                ifTrue: [worldState recordDamagedRect: (damageRect intersect: self bounds)]
                ifFalse: [super invalidRect: damageRect from: aMorph]
