﻿using IneorTaskBackend.Model;
using System.Collections.Generic;
using IneorTaskBackend.Model.Login;

namespace IneorTaskBackend.Helpers
{
    /// <summary>
    /// Helper for populating the initial empty database
    /// </summary>
    public static class SeedHelper
    {
        public static List<Beach> GetBeachesSeedData() => new()
        {
            new Beach
            {
                Id = "17faaab2-a385-4b06-aec7-7a8ccc5d10ac",
                Name = "Banyan Tree Vabbinfaru",
                Description = "Built on an almost perfectly circular island, with 48 villas and unpretentious barefoot luxury, Banyan Tree Vabbinfaru remains a favorite place for romantic couples and eco-lovers.Located in North Male Atoll, \"Vabbinfaru\" in Divehi means \"a round island surrounded by a coral reef.\" The simplicity of the name embodies the philosophy of the hotel. Enjoy the white sandy beach, flourishing coconut trees and tropical sunshine of one of the most popular global holiday destinations.Those who are looking for an underwater spa or swimming pool in the Maldives can be disappointed. The resort does not consider it necessary to build a swimming pool, because the ocean is simply beautiful. The sister resorts of Banyan Tree Vabbinfaru and Angsana Ihuru are certainly a luxury category, but prefer to stay away from the brilliant, tourist amenities such as a large swimming pool and over-water villas.",
                ImageUrl = "https://maldives-magazine.com/pictures/banyantree-indian-ocean.jpg",
                Country = "MV",
            },
            new Beach
            {
                Id = "1e50b9fa-6665-426c-a330-cc28ba8496cd",
                Name = "Saud Beach",
                Description = "The jewel in the crown of Pagudpud is Saud Beach, with its renowned wonderful fine white sand. The waters of the South China Sea are a magnificent blue and crystal clear all the time. This is bordered by spectacular multi-coloured corals and iridescent fish.The beach is lined with over hanging coconut palms, creating a scene from a dream. A popular venue for fashion photo shoots. The very best thing is that there are not too many people on the beach. While people keep comparing it to White Beach on Boracay Island, Saud Beach is simply what Boracay once was, and everything Boracay is not. It is not commercialized.There is no noise, no pollution at Saud Beach! The best of the beaches in the Philippines if not the world. It is also becoming the best place for surfing in Ilocos and also surfing Philippines when the large Pacific swells roll in.",
                ImageUrl = "https://www.pagudpud-ilocos.com/images/xsaudbeach.jpg.pagespeed.ic.5DPle5WXno.jpg",
                Country = "PH",
            },
            new Beach
            {
                Id = "6f0a950e-bf1f-4c7b-980f-4ae9a91df81b",
                Name = "Porto Istana",
                Description = "This beach is located a short distance from Porto San Paolo, near Murta Maria south of Olbia. White sand and emerald sea. The beach is connected to Olbia with a bus service. Porto Istana is actually a set of four beaches separated from each other by small rocky bands.The sand is made of fine and white sand that gently slopes towards the emeralds waters, so it is particularly suitable for bathing especially for children. Situated in front of the island of Tavolara is the destination of numerous enthusiasts of divers and surfers.",
                ImageUrl = "https://www.blualghero-sardinia.com/wp-content/uploads/2017/05/Porto_istana_4-1024x682.jpg",
                Country = "IT",
            },
            new Beach
            {
                Id = "8f5281f5-377f-45f4-8d54-a2f024aa20df",
                Name = "Elafonissi",
                Description = "Elafonisi is located 76km west of Chania and 5km south of Chrysoskalitisa Monastery, in the southwesternmost tip of Crete. Elafonisi is an oblong peninsula, which often breaks in two parts by water giving the impression of being a separate island. It is a Natura 2000 protected area. The island is full of sand dunes with sea daffodils and jupiners.Exotic beaches with white sand and turquoise water, reminding of the Caribbean, are formed on either sides of the peninsula. The sand is pinkish in many places, taking its color from millions of crushed shells. Near the breaking point of the peninsula, the sea water does not exceed 1m in depth, creating a small lagoon, ideal for children. You can easily cross the lagoon in order to reach the opposite site of the peninsula, while carrying your staff with you, because the water is very shallow there.",
                ImageUrl = "https://www.cretanbeaches.com/images/stories/beaches/chania/elafonisi/1.jpg",
                Country = "GR",
            },
            new Beach
            {
                Id = "a287b3b7-ec02-4936-a976-1d472565de08",
                Name = "Le Morne",
                Description = "Go to just about any shore in Mauritius, and you'll find a reef-protected beach with calm, clear water ideal for swimming, kayaking, and snorkeling. Le Morne is particularly noteworthy for its two-and-a-half miles of sugar-soft sand (beaches in Mauritius are often rough with broken-up coral) densely lined with palm and pine-like filao trees. The sheltered lagoon waters stretch to the horizon and the kitesurfing conditions are perhaps the best in the world. For dramatic effect, the nearby Le Morne Mountain looms large.",
                ImageUrl = "https://a.travel-assets.com/findyours-php/viewfinder/images/res70/112000/112530-Le-Morne.jpg",
                Country = "MU",
            },
            new Beach
            {
                Id = "c5fc53d7-175c-49de-b071-85af9a7fb443",
                Name = "Anse Source D'Agent",
                Description = "Anse Source d’Argent, in the south-west of La Digue, has often been described as the most beautiful beach in the world, and it is certainly one of the Seychelles’ most famous attractions. The beautiful mix of turquoise water, golden sand, and impressive boulders makes it a unique prospect worldwide. Access to Anse Source d’Argent is via the Union Estate, which charges 115 Rupees per person each day for access, however the outcome is well-worth the fee. The shallow, clear water, as well as the coral reef protection, means the beach is a great spot for families, and is also perfect for swimming and snorkelling. It can be difficult to swim here at low tide, as the water is extremely shallow, but at high tide, the water is deep enough to swim while still being shallow enough to be safe for most swimmers. The protection provided to the beach by the coral reef ensures that the open ocean feels far away, so parents shouldn’t worry about their kids playing in the water.",
                ImageUrl = "https://www.seyvillas.com/img/beaches/15/2530x1467_50/la-digue-anse-source-d-argent-02.webp",
                Country = "SC",
            },
            new Beach
            {
                Id = "e2c5d263-01e5-4e43-9e34-e3d1104a6a18",
                Name = "Whitehaven Beach",
                Description = "In terms of must-visit sites in Australia, Whitehaven Beach is up there with Sydney Opera House and Noosa National Park. From above, the destination's ever-shifting swirl of salt-white sand and brilliant blue water resemble a precious marbled jewel. (Hike to the panoramic Hill Inlet Lookout for one of the best views of your life.) Made of extremely fine, silica-rich quartz, the squeaky-soft sand is some of the smoothest and whitest in the world.",
                ImageUrl = "https://queensland.com/content/dam/teq/consumer/global/images/destinations/the-whitsundays/blog-imges/2020_WYS_WhitehavenBeach_Beaches_JamesVodicka_142946.jpg",
                Country = "AU",
            },
            new Beach
            {
                Id = "e2ea1430-bbd9-44ea-b64e-9ccd0720811d",
                Name = "Sotavento, Fuerteventura",
                Description = "Fuerteventura could be described in a single word: beaches. Describing the incredible vista of Sotavento is easy: it's the islands best known beach in the world. Just its length, about nine kilometres, leaves visitors speechless. At low tide, the island gains so much land that some residents doubt that Tenerife is the largest of the Canary Islands. The huge lagoons that are created at low tide, the constant sunshine and infinite golden sand make it worthy of another synonym: paradise.In reality, Sotavento is made up of five beaches: La Barca, Risco del Paso, Mirador, Los Canarios and Malnombre. With endless walks next to its clear waters there is no need to wait for low tide. A sand barrier at 100 and 300 metres from the shore creates a lagoon three kilometres long, perfect for beginners to windsurfing or kitesurfing; of which there are many. Turn around and take in a wonderful scene of solitude, with thousands of metres of sand and ocean before you. A real treat",
                ImageUrl = "https://www.westend61.de/images/0001378315pw/aerial-view-of-sotavento-beach-lagoon-in-costa-calma-fuerteventura-canary-islands-AAEF08639.jpg",
                Country = "ES",
            },
        };

        public static List<User> GetUsersSeedData() => new()
        {
            new User
            {
                Id = "03ff811d-7873-4ea7-934e-d391042a73fe",
                Username = "admin",
                Password = "t+10+QkbwtG+XAjF5NC5YvlW7D2S4pEZ55+/wP72q4g=",
                PasswordSalt = "zgTSXVdN6ml3ZaPkW6u/l7zLaeYElU03tiyORHxd/j8=",
                Role = "admin"
            },
            new User
            {
                Id = "0875206c-a23a-4136-9994-82883dd03073",
                Username = "user",
                Password = "jRBSSE+HuB4PSa52gxD71nFbKdV6YyLvkJZvk9mT1Ao=",
                PasswordSalt = "s0eqy73U2hqAEHcoQ4LAo6maSshjllhQzoh28Ag7W4o="
            },
        };
    }
}
