show8

    " B3DDemoSurfaces new show8"

     | view |

  self createScene8.
  (view := B3DTutorialScenePresenterMorph new)
     source: self description: #descriptionScene8;
     scene: scene.
  view rotateX: 12.0.
  view clearColor: (Color gray: 0.86).

  
  view addFrameAndExplanationField openInWorldExtent: Display extent x//2 @ (Display extent y * 7 // 8).